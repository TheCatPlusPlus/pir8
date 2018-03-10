using System;

using JetBrains.Annotations;

using PIR8.ISA.Assembly.AST;
using PIR8.ISA.Utils;

namespace PIR8.ISA.Assembly.Pipeline.AssemblerPasses
{
	internal sealed class Collect : AssemblerPass
	{
		public Collect(AssemblerState state)
			: base("collect", state)
		{
		}

		protected override void DoRun()
		{
			// first pass: collect all the names, calculate label offsets
			// (as indices into the instructions list first), match instructions to impls
			var offset = 0u;

			foreach (var node in State.Source.Children)
			{
				switch (node)
				{
					case ConstantDefNode constant:
						OnConstant(constant);
						break;
					case LabelNode label:
						OnLabel(offset, label);
						break;
					case InstructionNode insn:
						OnEncodable(ref offset, insn);
						break;
					case DataNode data:
						OnEncodable(ref offset, data);
						break;
				}
			}
		}

		private void OnConstant(ConstantDefNode def)
		{
			if (State.Consts.ContainsKey(def.Name))
			{
				State.Warning(
					def,
					$"constant {def.Name} redefined (first defined on {PreviousLocation(def.Name)}), only the latest definition will have effect");
			}

			if (State.Labels.ContainsKey(def.Name))
			{
				State.Error(
					def,
					$"name {def.Name} has already been used as a label at {PreviousLocation(def.Name)}");
				return;
			}

			State.Names[def.Name] = def;
			State.Consts[def.Name] = def.Value;
		}

		private void OnEncodable(ref uint offset, EncodableNode encodable)
		{
//			State.Encodables.Add(encodable);
			++offset;
		}

		private void OnLabel(uint offset, LabelNode node)
		{
			var label = node.Name;

			if (State.Consts.ContainsKey(label))
			{
				State.Error(
					node, $"name {label} has already been used a constant name at {PreviousLocation(label)}");
				return;
			}

			if (State.Labels.ContainsKey(label))
			{
				State.Error(node, $"label {label} redefined (first defined on {PreviousLocation(label)}");
				return;
			}

			State.Names[label] = node;
			State.Labels[label] = offset;
		}

		private string PreviousLocation([CanBeNull] string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			return State.Names[name].GetLocation();
		}
	}
}

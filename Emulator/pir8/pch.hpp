#pragma once

#if !defined(__RESHARPER__) && !defined(__INTELLISENSE__) && !defined(PIR8_NO_PCH)
#	include <stdexcept>
#	include <memory>
#	include <utility>
#	include <array>
#	include <vector>
#	include <unordered_set>
#	include <unordered_map>
#	include <iostream>
#	include <fstream>
#	include <sstream>
#	include <algorithm>
#	include <deque>
#	include <new>
#	include <typeindex>
#	include <typeinfo>
#	include <functional>
#	include <thread>
#	include <atomic>
#	include <variant>
#	include <optional>
#	include <random>
#	include <type_traits>
#	include <limits>
#	include <string>
#	include <cstdint>
#	include <map>
#	include <set>
#	include <bitset>

#	include <gsl/gsl_byte>
#	include <gsl/span>
#	include <gsl/multi_span>
#	include <gsl/string_span>
#	include <gsl/pointers>
#	include <gsl/gsl_algorithm>

#	include <boost/filesystem.hpp>
#	include <boost/algorithm/string.hpp>
#	include <boost/exception/all.hpp>
#	include <boost/stacktrace.hpp>

#	include <fmt/format.h>
#	include <fmt/ostream.h>
#endif

#define PIR8_NS_ALIAS(ns, alias) \
	namespace ns {} \
	namespace alias = ns

PIR8_NS_ALIAS(boost::filesystem, fs);
PIR8_NS_ALIAS(boost::algorithm, algo);

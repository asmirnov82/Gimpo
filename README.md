# Gimpo
Gimpo project was inspired by both Microsoft Data Analysis and Apache Arrow. It is intended to provide a set of data structures and building blocks for data analytics.

Mostly I am going to use it for experimenting with alternative implementation and ideas before proposing change requests into original libraries. 

## Gimpo DataFrame
Provides a DataFrame - tabular data structure common to many data processing libraries. Gimpo DataFrame is fully compatible with Apache Arrow [format](https://arrow.apache.org/docs/format/Columnar.html).

## Gimpo Data Primitives
The array size in C# is limited to maximum index of 0x7FFFFFC7(2,147,483,591), [Array.MaxLength](https://docs.microsoft.com/en-us/dotnet/api/system.array.maxlength). Framework classes [`Span<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.span-1) and [`Memory<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) both have the same restriction. In terms of `bytes[]`, it is about 2GB, which is very low in the modern world. Classes provided by Gimpo Data Primitives use native memory and allow to go beyond this limit.

Currenly it contains:
- *NativeMemoryBuffer* - the simplest abstraction over a contiguous memory block. Provides method to allocate/dispose, indexing, resizing and cloning.
- *NativeMemoryVector* - vector (or `List` in term of C#) for storing structs. 
- *NativeMemoryNullableVector* - the same as NativeMemoryVector, but allows to store nullable structs. 
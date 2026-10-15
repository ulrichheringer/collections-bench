# collections-bench

Compare lookups in arrays, `List<T>`, `HashSet<T>`, and sorted arrays with repeatable data and measurements.

## Run

Requires the .NET 10 SDK. Browser builds also need the WebAssembly workload: `dotnet workload install wasm-tools`.

### Desktop

~~~sh
dotnet run --project CollectionsBench.Desktop/CollectionsBench.Desktop.csproj
~~~

### Browser

~~~sh
dotnet run --project CollectionsBench.Browser/CollectionsBench.Browser.csproj
~~~

## Example

Run five rounds with 15,000 values and 1,500 lookups.

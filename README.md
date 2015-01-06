Tryer
=====

A little syntactic sugar for ugly try-catch blocks in C#

Converts this..

```c#
string value = null;
Exception exception = null;

try
{
	value = SomeFunctionWhichThrows();
}
catch(Exception e)
{
	exception = e;
}

if (exception != null)
	Log(exception);

return value;
```

into this...

```c#
var result = Try.Func(SomeFunctionWhichThrows);

if (result.Error)
	Log(result.Exception);
	
return result.value;
```

It supports actions and awaiting async methods as well.

A try-catch around and awaited method call becomes...

```c#
public async void OnButtonClick()
{
	var tryResult = await GetSomethingFromADatabaseAsync().TryAwait();

	if (tryResult.Error)
	{
		DisplayErrorMessage();
		return;
	}

	Process(tryResult.Value);
}
```

It also makes it possible to test certain functions without mocks if you wished to.
Simply construct and pass a TryResult to a function and assert the results.
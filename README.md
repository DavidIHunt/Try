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

Supports actions and awaiting async methods.

### Examples ###

TODO
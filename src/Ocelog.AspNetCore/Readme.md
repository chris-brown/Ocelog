```cs
WebHost.CreateDefaultBuilder(args)
	.ConfigureLogging((context, builder) =>
	{
		builder.AddFilter((s, s1, arg3) => { return false; });
		builder.AddOcelog();
	})
```
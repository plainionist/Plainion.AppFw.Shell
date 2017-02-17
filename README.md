
Are you also writing little tools every now and then to simplify and automate your work?

You do not want to use Perl, Python or Ruby because you are on a Windows box where these 
languages are usually not installed by default? Same for the boxes of your colleagues?

So you decide for .NET which is always available ... but creating a new project every time,
parsing commandlines from scratch every time and writing the same dumb usage output every time
is boring if not even anoying?


# Here is your solution! :)

## Only Once

1. Create your *last* scripting solution 
2. Download and install this library from [NuGet](https://www.nuget.org/packages/Plainion.AppFw.Shell/) ![NuGet Version](https://img.shields.io/nuget/v/Plainion.AppFw.Shell.svg?style=flat-square)
3. Download [Plainion.Starter](https://github.com/plainionist/Plainion.AppFw.Shell/releases), unzip it and put
   it into our "bin" folder (a location where you put all our tools so that you can easily reach it from
   command line)

## For ever script

you write from now on create 1 XAML file and 1 C# class like this

```Xaml
<?xml version="1.0" encoding="utf-8" ?>
<Script xmlns="http://github.com/ronin4net/plainion/appfw/shell" 
        xmlns:s="clr-namespace:Plainion.Scripts.Loc;assembly=Plainion.Scripts" 
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Script.Option>-Loc</Script.Option>
    <Script.Description>Runs LOC metric</Script.Description>
    <s:LinesOfCode/>
</Script>
```  

In Visual Studio set "Copy to output directory" to "Copy if newer".

```C#
public class LinesOfCode : FormsAppBase
{
    [Argument( Short = "-s", Description = "Project sources root" )]
    public string Source { get; set; }

    [Argument( Short = "-o", Long = "-output", Description = "Report output file" )]
    public string Output { get; set; }

    protected override void Run()
    {
            ... your business logic goes here ...
    }
}
```  

And now run your script with

```
Plainion.Starter -D [folder of your Xaml file] -Loc
```

# That's it!

- **NO** CommandLine parsing anylonger
- **NO** boring Program.cs boilerplate code anylonger
- **NO** boring usage print out anylonger


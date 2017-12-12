mkdir lib
mkdir lib\netcoreapp2.0
mkdir tools
mkdir content
mkdir content\controllers

copy ..\src\Ocelog\bin\netcoreapp2.0\Ocelog.dll lib\netcoreapp2.0
copy ..\src\Ocelog.Formatting.Json\bin\netcoreapp2.0\Ocelog.Formatting.Json.dll lib\netcoreapp2.0
copy ..\src\Ocelog.Formatting.Logstash\bin\netcoreapp2.0\Ocelog.Formatting.Logstash.dll lib\netcoreapp2.0
copy ..\src\Ocelog.Transport.UDP\bin\netcoreapp2.0\Ocelog.Transport.UDP.dll lib\netcoreapp2.0
copy ..\src\Ocelog.Testing\bin\netcoreapp2.0\Ocelog.Testing.dll lib\netcoreapp2.0

copy ..\src\Ocelog\bin\netcoreapp2.0\Ocelog.pdb lib\netcoreapp2.0
copy ..\src\Ocelog.Formatting.Json\bin\netcoreapp2.0\Ocelog.Formatting.Json.pdb lib\netcoreapp2.0
copy ..\src\Ocelog.Formatting.Logstash\bin\netcoreapp2.0\Ocelog.Formatting.Logstash.pdb lib\netcoreapp2.0
copy ..\src\Ocelog.Transport.UDP\bin\netcoreapp2.0\Ocelog.Transport.UDP.pdb lib\netcoreapp2.0
copy ..\src\Ocelog.Testing\bin\netcoreapp2.0\Ocelog.Testing.pdb lib\netcoreapp2.0

copy ..\src\Ocelog\bin\netcoreapp2.0\Ocelog.deps.json lib\netcoreapp2.0
copy ..\src\Ocelog.Formatting.Json\bin\netcoreapp2.0\Ocelog.Formatting.Json.deps.json lib\netcoreapp2.0
copy ..\src\Ocelog.Formatting.Logstash\bin\netcoreapp2.0\Ocelog.Formatting.Logstash.deps.json lib\netcoreapp2.0
copy ..\src\Ocelog.Transport.UDP\bin\netcoreapp2.0\Ocelog.Transport.UDP.deps.json lib\netcoreapp2.0
copy ..\src\Ocelog.Testing\bin\netcoreapp2.0\Ocelog.Testing.deps.json lib\netcoreapp2.0

nuget pack -Symbols

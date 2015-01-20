Swagger WebApiProxy
============
Goal is to create a build task that will consume a Swagger 2.0 Spec and create a webproxy for consuming that service

Resolving JSON.Net
--------

Due to the way T4 templates work, special care is needed to bring in JSON.Net.

Add the following code to your csproj file to point the T4 engine to your JSON.Net instance

```
  <PropertyGroup>
    <myLibFolder>$(MSBuildProjectDirectory)\..\..\packages\Newtonsoft.Json.6.0.6\lib\net45</myLibFolder>
  </PropertyGroup>
  <!-- Tell the MSBuild T4 task to make the property available: -->
  <ItemGroup>
    <T4ParameterValues Include="myLibFolder">
      <Value>$(myLibFolder)</Value>
      <InProject>False</InProject>
    </T4ParameterValues>
  </ItemGroup>
```
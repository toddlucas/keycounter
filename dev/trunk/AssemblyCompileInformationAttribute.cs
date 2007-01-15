namespace System.Reflection
{
	[AttributeUsage(AttributeTargets.Assembly,AllowMultiple=false)]
	class AssemblyCompileInformationAttribute : Attribute
	{
		public string CompileDate {get{return "2007-01-15";}}
		public string CompileTime {get{return "00:00:46";}}
	}
}

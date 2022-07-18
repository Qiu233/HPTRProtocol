namespace PacketTests;

[AttributeUsage(AttributeTargets.Method)]
internal class TestedForAttribute : Attribute
{
	public string Version { get; set; }

	public TestedForAttribute(string version)
	{
		Version = version;
	}
}
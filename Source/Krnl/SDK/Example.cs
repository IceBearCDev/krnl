using System;

public class Executor
{
   private string Version { get; set; }
   
   public Executor(string version)
   {
      this.Version = version;
   }
   
   public void Execute(string script)
   {
      Console.WriteLine("Executing script: " + script);
   }
   
   public void SetVersion(string version)
   {
      this.Version = version;
   }
   
   public string GetVersion()
   {
      return this.Version;
   }
}

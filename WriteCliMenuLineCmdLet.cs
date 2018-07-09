﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace SS.CliMenu
{
    /// <summary>
    /// 
    /// <para type="synopsis"></para>
    /// <para type="description"></para>
    /// <example>
    ///   <title>Default usage.</title>
    ///   <description></description>
    ///   <code>Write-CliMenuLine "Menu line item"</code>
    /// </example>
    /// <example>
    ///   <title>Default usage with script.</title>
    ///   <description></description>
    ///   <code>Write-CliMenuLine -Script { Write-Host "test" }</code>
    /// </example>
    /// </summary>
    [Cmdlet(VerbsCommunications.Write, "CliMenuLine")]
    public class WriteCliMenuLineCmdLet : UICmdLet
    {
        /// <summary>
        /// 
        /// <para type="description"></para>
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "ByText", ValueFromPipeline = true, Position = 0)]
        public string Text { get; set; }
        /// <summary>
        /// 
        /// <para type="description"></para>
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "ByScript")]
        public ScriptBlock Script { get; set; }
        /// <summary>
        /// 
        /// <para type="description"></para>
        /// </summary>
        [Parameter]
        public ConsoleColor Color { get; set; } = System.ConsoleColor.White;
        /// <summary>
        /// 
        /// <para type="description"></para>
        /// </summary>
        [Parameter]
        public SwitchParameter IsMenuItem { get; set; }

        protected override void ProcessRecord()
        {
            opts = GetVariableValue("CliMenuOptions", new CliMenuOptions(this.Host)) as CliMenuOptions;

            if (Script != null)
                base.WriteMenuLine(Script, Color, IsMenuItem);
            else
                base.WriteMenuLine(Text, Color, IsMenuItem);

            base.ProcessRecord();
        }
    }
}
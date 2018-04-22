// Fill out your copyright notice in the Description page of Project Settings.

using UnrealBuildTool;

using System;
using System.IO;

public class AugmentedUnrealityEx : ModuleRules
{
	public AugmentedUnrealityEx(ReadOnlyTargetRules Target) : base(Target)
	{
		PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore" });

		PrivateDependencyModuleNames.AddRange(new string[] {  });

		// Uncomment if you are using Slate UI
		// PrivateDependencyModuleNames.AddRange(new string[] { "Slate", "SlateCore" });

		// Uncomment if you are using online features
		// PrivateDependencyModuleNames.Add("OnlineSubsystem");

		// To include OnlineSubsystemSteam, add it to the plugins section in your uproject file with the Enabled attribute set to true

		AdditionalPropertiesForReceipt.Add(
			new ReceiptProperty("AndroidPlugin", Path.Combine(ModuleDirectory, "AndroidSanitizePermissions_UPL.xml"))
		);

		// Program crashes on "Launch on Android" without the network permission
		// so let's only disable it for shipping configuration
		if(Target.Configuration == UnrealBuildTool.UnrealTargetConfiguration.Shipping)
		{
			AdditionalPropertiesForReceipt.Add(
				new ReceiptProperty("AndroidPlugin", Path.Combine(ModuleDirectory, "AndroidRemoveNetworkPermission_UPL.xml"))
			);
		}
	}
}

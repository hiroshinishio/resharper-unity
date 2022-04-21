package com.jetbrains.rider.plugins.unity.run

import com.intellij.openapi.project.Project
import com.jetbrains.rider.plugins.unity.run.configurations.UnityDebugConfigurationType
import com.jetbrains.rider.plugins.unity.run.configurations.unityExe.UnityExeConfigurationType
import com.jetbrains.rider.run.configurations.RiderNewRunConfigurationTreeGroupingProvider
import UnityIcons

class UnityNewRunConfigurationTreeGroupingProvider: RiderNewRunConfigurationTreeGroupingProvider {
    override fun getGroups(project: Project): List<RiderNewRunConfigurationTreeGroupingProvider.Group> {
        return listOf(RiderNewRunConfigurationTreeGroupingProvider.Group(
            UnityIcons.Icons.UnityLogo, "Unity",
            listOf(
                UnityDebugConfigurationType.id,
                UnityExeConfigurationType.id
            )
        ))
    }
}
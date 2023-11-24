package com.jetbrains.rider.plugins.unity.ui.shaders

import com.intellij.internal.statistic.IdeActivityDefinition
import com.intellij.internal.statistic.StructuredIdeActivity
import com.intellij.internal.statistic.eventLog.EventLogGroup
import com.intellij.internal.statistic.eventLog.events.EventFields
import com.intellij.internal.statistic.service.fus.collectors.CounterUsagesCollector
import com.intellij.openapi.diagnostic.thisLogger
import com.intellij.openapi.project.Project
import com.jetbrains.rider.plugins.unity.model.frontendBackend.RdShaderApi
import com.jetbrains.rider.plugins.unity.model.frontendBackend.RdShaderPlatform

class ShaderVariantEventLogger : CounterUsagesCollector() {
    companion object {

        private val SHADER_API = EventFields.Enum<RdShaderApi>("shader_api")
        private val SHADER_PLATFORM = EventFields.Enum<RdShaderPlatform>("shader_platform")
        val CONTEXT_COUNT = EventFields.RoundedInt("context_count")
        val DEFINE_COUNT = EventFields.RoundedInt("define_count")

        @JvmField
        internal val GROUP = EventLogGroup("rider.unity.shaders.variants", 2)

        private val SHOW_SHADER_VARIANT_POPUP_ACTIVITY = GROUP.registerIdeActivity("show_variants", finishEventAdditionalFields = arrayOf(
            DEFINE_COUNT
        ))

        private val RESET_KEYWORDS = GROUP.registerEvent("reset")
        private val RESET_ALL_KEYWORDS = GROUP.registerEvent("reset_all")
        private val API_CHANGED = GROUP.registerEvent("shader_api_changed", SHADER_API)
        private val PLATFORM_CHANGED = GROUP.registerEvent("shader_platform_changed", SHADER_PLATFORM)
        private val DEFINE_CHANGED = GROUP.registerEvent("define_changed")


        private val SHOW_SHADER_CONTEXT_POPUP_ACTIVITY = GROUP.registerIdeActivity("show_contexts", finishEventAdditionalFields = arrayOf(
            CONTEXT_COUNT
        ))
        private val SELECT_CONTEXT = GROUP.registerEvent("select_context")
        private val LEARN_MORE = GROUP.registerEvent("clicked_learn_more")


        fun logShowShaderVariantPopupStarted(project: Project) : StructuredIdeActivity? {
            try {
                return SHOW_SHADER_VARIANT_POPUP_ACTIVITY.started(project)
            } catch (e: Throwable) {
                thisLogger().error(e)
                return null
            }
        }


        fun logShowShaderContextsPopupStarted(project: Project) : StructuredIdeActivity? {
            try {
                return SHOW_SHADER_CONTEXT_POPUP_ACTIVITY.started(project)
            } catch (e: Throwable) {
                thisLogger().error(e)
                return null
            }
        }


        fun logResetKeywords(project: Project) {
            RESET_KEYWORDS.log(project)
        }

        fun logResetAllKeywords(project: Project) {
            RESET_ALL_KEYWORDS.log(project)
        }

        fun logApiChanged(project: Project, api: RdShaderApi) {
            API_CHANGED.log(project, api)
        }

        fun logPlatformChanged(project: Project, api: RdShaderPlatform) {
            PLATFORM_CHANGED.log(project, api)
        }

        fun logDefineChanged(project: Project) {
            DEFINE_CHANGED.log(project)
        }

        fun logSelectContext(project: Project) {
            SELECT_CONTEXT.log(project)
        }

        fun logLearnMore(project: Project) {
            LEARN_MORE.log(project)
        }

    }

    override fun getGroup() = GROUP
}
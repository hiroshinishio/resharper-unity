package com.jetbrains.rider.plugins.unity.ui.vcs

import com.intellij.openapi.components.*
import com.intellij.openapi.project.Project
import com.jetbrains.rider.util.idea.getService
import org.jdom.Element

@Service(Service.Level.PROJECT)
@State(name = "MetaFilesCheckinStateConfiguration", storages = [(Storage(StoragePathMacros.WORKSPACE_FILE))])
class MetaFilesCheckinState(val project: Project) : PersistentStateComponent<Element> {

    companion object {
        fun getService(project: Project) = project.getService<MetaFilesCheckinState>()
        const val attributeName = "checkMetaFiles"
    }

    var checkMetaFiles: Boolean = true

    override fun getState(): Element {
        val element = Element("state")
        element.setAttribute(attributeName, checkMetaFiles.toString())
        return element
    }

    override fun loadState(element: Element) {
        val attributeValue = element.getAttributeBooleanValue(attributeName)
        checkMetaFiles = attributeValue
    }
}
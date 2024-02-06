package com.jetbrains.rider.unity.test.cases
import com.jetbrains.rider.test.allure.SubsystemConstants
import com.jetbrains.rider.test.annotations.Feature
import com.jetbrains.rider.test.annotations.Subsystem
import com.jetbrains.rider.unity.test.framework.base.FindUsagesAssetTestBase
import com.jetbrains.rider.test.annotations.TestEnvironment
import com.jetbrains.rider.test.enums.PlatformType
import com.jetbrains.rider.test.env.enums.SdkVersion
import com.jetbrains.rider.test.scriptingApi.setGroupingEnabled
import io.qameta.allure.Severity
import io.qameta.allure.SeverityLevel
import org.testng.annotations.Test

@Subsystem(SubsystemConstants.UNITY_FIND_USAGES)
@Feature("Unity Assets Find Usages")
@Severity(SeverityLevel.CRITICAL)
@TestEnvironment(platform = [PlatformType.ALL], sdkVersion = SdkVersion.DOT_NET_6)
open class FindUsagesAssetTest : FindUsagesAssetTestBase() {

    override fun getSolutionDirectoryName(): String {
        return "FindUsages_event_handlers_2017"
    }

    @Test(description = "Find script usages with Unity2017 scene model", dataProvider = "findUsagesGrouping")
    fun findScript_2017(caseName: String, groups: List<String>?) {
        disableAllGroups()
        groups?.forEach { group -> setGroupingEnabled(group, true) }

        doTest(5, 17)
    }

    @Test(description = "Find EventHandler usages with Unity2017 scene model", dataProvider = "findUsagesGrouping")
    fun findEventHandler_2017(caseName: String, groups: List<String>?) {
        disableAllGroups()
        groups?.forEach { group -> setGroupingEnabled(group, true) }

        doTest(17, 18)
    }

    @Test(description = "Find script usages with Unity2017 scene model", dataProvider = "findUsagesGrouping")
    @TestEnvironment(solution = "FindUsages_02_2017")
    fun findScript_02_2017(caseName: String, groups: List<String>?) {
        disableAllGroups()
        groups?.forEach { group -> setGroupingEnabled(group, true) }

        doTest(5, 17)
    }

    @Test(description = "Find script usages with Unity2017 scene model", dataProvider = "findUsagesGrouping")
    @TestEnvironment(solution = "FindUsages_03_2017")
    fun findScript_03_2017(caseName: String, groups: List<String>?) {
        disableAllGroups()
        groups?.forEach { group -> setGroupingEnabled(group, true) }

        doTest(5, 17)
    }

    @Test(description = "Find script usages with Unity2017 scene model", dataProvider = "findUsagesGrouping")
    @TestEnvironment(solution = "FindUsages_04_2017")
    fun findScript_04_2017(caseName: String, groups: List<String>?) {
        disableAllGroups()
        groups?.forEach { group -> setGroupingEnabled(group, true) }

        doTest(5, 17)
    }

    @Test(description = "Find script usages with Unity2018 scene model", dataProvider = "findUsagesGrouping")
    fun findScript_2018(caseName: String, groups: List<String>?) {
        disableAllGroups()
        groups?.forEach { group -> setGroupingEnabled(group, true) }

        doTest(5, 17)
    }

    @Test(description = "Find EventHandler usages with Unity2018 scene model", dataProvider = "findUsagesGrouping")
    fun findEventHandler_2018(caseName: String, groups: List<String>?) {
        disableAllGroups()
        groups?.forEach { group -> setGroupingEnabled(group, true) }

        doTest(17, 18)
    }

    @Test(description = "Find EventHandlerPrefabs usages with Unity2018 scene model", dataProvider = "findUsagesGrouping")
    @TestEnvironment(solution = "FindUsages_event_handlers_prefabs_2018")
    fun findEventHandlerPrefabs_2018(caseName: String, groups: List<String>?) {
        disableAllGroups()
        groups?.forEach { group -> setGroupingEnabled(group, true) }

        doTest(17, 18)
    }


    @Test(description = "Find script usages with Unity2018 scene model", dataProvider = "findUsagesGrouping")
    @TestEnvironment(solution = "FindUsages_02_2018")
    fun findScript_02_2018(caseName: String, groups: List<String>?) {
        disableAllGroups()
        groups?.forEach { group -> setGroupingEnabled(group, true) }

        doTest(5, 17)
    }

    @Test(description = "Find script usages with Unity2018 scene model", dataProvider = "findUsagesGrouping")
    @TestEnvironment(solution = "FindUsages_03_2018")
    fun findScript_03_2018(caseName: String, groups: List<String>?) {
        disableAllGroups()
        groups?.forEach { group -> setGroupingEnabled(group, true) }

        doTest(5, 17)
    }

    @Test(description = "Find script usages with Unity2018 scene model", dataProvider = "findUsagesGrouping")
    @TestEnvironment(solution = "FindUsages_04_2018")
    fun findScript_04_2018(caseName: String, groups: List<String>?) {
        disableAllGroups()
        groups?.forEach { group -> setGroupingEnabled(group, true) }

        doTest(5, 17)
    }

    @Test(description = "Find script usages with Unity2018 scene model", dataProvider = "findUsagesGrouping")
    @TestEnvironment(solution = "FindUsages_05_2018")
    fun findScript_05_2018(caseName: String, groups: List<String>?) {
        disableAllGroups()
        groups?.forEach { group -> setGroupingEnabled(group, true) }

        doTest(5, 17)
    }

    @Test(description = "Find VoidHandler usages", dataProvider = "findUsagesGrouping")
    @TestEnvironment(solution = "FindUsages_event_handlers_2018")
    fun findVoidHandler(caseName: String, groups: List<String>?) {
        doTest(11, 17, groups)
    }

    @Test(description = "Find IntHandler usages", dataProvider = "findUsagesGrouping")
    @TestEnvironment(solution = "FindUsages_event_handlers_2018")
    fun findIntHandler(caseName: String, groups: List<String>?) {
        doTest(14, 17, groups)
    }

    @Test(description = "Find FloatHandler usages", dataProvider = "findUsagesGrouping")
    @TestEnvironment(solution = "FindUsages_event_handlers_2018")
    fun findFloatHandler(caseName: String, groups: List<String>?) {
        doTest(17, 17, groups)
    }

    @Test(description = "Find BoolHandler usages", dataProvider = "findUsagesGrouping")
    @TestEnvironment(solution = "FindUsages_event_handlers_2018")
    fun findBoolHandler(caseName: String, groups: List<String>?) {
        doTest(20, 17, groups)
    }

    @Test(description = "Find ObjectHandler usages", dataProvider = "findUsagesGrouping")
    @TestEnvironment(solution = "FindUsages_event_handlers_2018")
    fun findObjectHandler(caseName: String, groups: List<String>?) {
        doTest(23, 17, groups)
    }

    @Test(description = "Find UnityEventHandler usages", dataProvider = "findUsagesGrouping")
    @TestEnvironment(solution = "FindUsages_event_handlers_2018")
    fun findUnityEventHandler(caseName: String, groups: List<String>?) {
        doTest(26, 17, groups)
    }

    @Test(description = "Find UnityEventHandler usages", dataProvider = "findUsagesGrouping")
    @TestEnvironment(solution = "FindUsages_event_handlers_2018")
    fun findPropertyHandler(caseName: String, groups: List<String>?) {
        doTest(29, 16, groups)
    }

    @Test(description = "Find PropertyHandler usages", dataProvider = "findUsagesGrouping")
    @TestEnvironment(solution = "FindUsages_event_handlers_2018")
    fun findPropertyHandler2(caseName: String, groups: List<String>?) {
        doTest(33, 16, groups)
    }

//    TODO: uncomment when local tests would fine
//    @Test(description = "Find AssetUsagesForOverriddenEventHandler usages", dataProvider = "findUsagesGrouping")
//    @TestEnvironment(solution = "FindUsagesOverriddenEventHandlers")
//    fun findAssetUsagesForOverriddenEventHandler(caseName: String, groups: List<String>?) {
//        doTest(7, 27, groups, "BaseScript.cs")
//    }
//
//    @Test(description = "Find AssetUsagesForOverriddenEventHandler usages", dataProvider = "findUsagesGrouping")
//    @TestEnvironment(solution = "FindUsagesOverriddenEventHandlers")
//    fun findAssetUsagesForOverriddenEventHandler2(caseName: String, groups: List<String>?) {
//        doTest(7, 27, groups, "DerivedScript.cs")
//    }
}
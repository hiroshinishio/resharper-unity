@file:Suppress("UnstableApiUsage")

package com.jetbrains.rider.plugins.unity.workspace

import com.intellij.workspaceModel.storage.*
import com.intellij.workspaceModel.storage.bridgeEntities.api.ContentRootEntity
import com.intellij.workspaceModel.storage.impl.*
import com.jetbrains.rider.plugins.unity.model.frontendBackend.UnityGitDetails
import com.jetbrains.rider.plugins.unity.model.frontendBackend.UnityPackage
import com.jetbrains.rider.plugins.unity.model.frontendBackend.UnityPackageSource

@GeneratedCodeApiVersion(1)
@GeneratedCodeImplVersion(1)
open class UnityPackageEntityImpl : UnityPackageEntity, WorkspaceEntityBase() {

  companion object {
    internal val CONTENTROOTENTITY_CONNECTION_ID: ConnectionId = ConnectionId.create(UnityPackageEntity::class.java,
                                                                                     ContentRootEntity::class.java,
                                                                                     ConnectionId.ConnectionType.ONE_TO_ONE, true)

    val connections = listOf<ConnectionId>(
      CONTENTROOTENTITY_CONNECTION_ID,
    )

  }

  @JvmField
  var _descriptor: UnityPackage? = null
  override val descriptor: UnityPackage
    get() = _descriptor!!

  override val contentRootEntity: ContentRootEntity?
    get() = snapshot.extractOneToOneChild(CONTENTROOTENTITY_CONNECTION_ID, this)

  override fun connectionIdList(): List<ConnectionId> {
    return connections
  }

  class Builder(val result: UnityPackageEntityData?) : ModifiableWorkspaceEntityBase<UnityPackageEntity>(), UnityPackageEntity.Builder {
    constructor() : this(UnityPackageEntityData())

    override fun applyToBuilder(builder: MutableEntityStorage) {
      if (this.diff != null) {
        if (existsInBuilder(builder)) {
          this.diff = builder
          return
        }
        else {
          error("Entity UnityPackageEntity is already created in a different builder")
        }
      }

      this.diff = builder
      this.snapshot = builder
      addToBuilder()
      this.id = getEntityData().createEntityId()

      // Process linked entities that are connected without a builder
      processLinkedEntities(builder)
      checkInitialization() // TODO uncomment and check failed tests
    }

    fun checkInitialization() {
      if (!getEntityData().isEntitySourceInitialized()) {
        error("Field WorkspaceEntity#entitySource should be initialized")
      }
      if (!getEntityData().isDescriptorInitialized()) {
        error("Field UnityPackageEntity#descriptor should be initialized")
      }
    }

    override fun connectionIdList(): List<ConnectionId> {
      return connections
    }

    // Relabeling code, move information from dataSource to this builder
    override fun relabel(dataSource: WorkspaceEntity, parents: Set<WorkspaceEntity>?) {
      dataSource as UnityPackageEntity
      this.entitySource = dataSource.entitySource
      this.descriptor = dataSource.descriptor
      if (parents != null) {
      }
    }


    override var entitySource: EntitySource
      get() = getEntityData().entitySource
      set(value) {
        checkModificationAllowed()
        getEntityData().entitySource = value
        changedProperty.add("entitySource")

      }

    override var descriptor: UnityPackage
      get() = getEntityData().descriptor
      set(value) {
        checkModificationAllowed()
        getEntityData().descriptor = value
        changedProperty.add("descriptor")

      }

    override var contentRootEntity: ContentRootEntity?
      get() {
        val _diff = diff
        return if (_diff != null) {
          _diff.extractOneToOneChild(CONTENTROOTENTITY_CONNECTION_ID, this) ?: this.entityLinks[EntityLink(true,
                                                                                                           CONTENTROOTENTITY_CONNECTION_ID)] as? ContentRootEntity
        }
        else {
          this.entityLinks[EntityLink(true, CONTENTROOTENTITY_CONNECTION_ID)] as? ContentRootEntity
        }
      }
      set(value) {
        checkModificationAllowed()
        val _diff = diff
        if (_diff != null && value is ModifiableWorkspaceEntityBase<*> && value.diff == null) {
          if (value is ModifiableWorkspaceEntityBase<*>) {
            value.entityLinks[EntityLink(false, CONTENTROOTENTITY_CONNECTION_ID)] = this
          }
          // else you're attaching a new entity to an existing entity that is not modifiable
          _diff.addEntity(value)
        }
        if (_diff != null && (value !is ModifiableWorkspaceEntityBase<*> || value.diff != null)) {
          _diff.updateOneToOneChildOfParent(CONTENTROOTENTITY_CONNECTION_ID, this, value)
        }
        else {
          if (value is ModifiableWorkspaceEntityBase<*>) {
            value.entityLinks[EntityLink(false, CONTENTROOTENTITY_CONNECTION_ID)] = this
          }
          // else you're attaching a new entity to an existing entity that is not modifiable

          this.entityLinks[EntityLink(true, CONTENTROOTENTITY_CONNECTION_ID)] = value
        }
        changedProperty.add("contentRootEntity")
      }

    override fun getEntityData(): UnityPackageEntityData = result ?: super.getEntityData() as UnityPackageEntityData
    override fun getEntityClass(): Class<UnityPackageEntity> = UnityPackageEntity::class.java
  }
}

class UnityPackageEntityData : WorkspaceEntityData<UnityPackageEntity>() {
  lateinit var descriptor: UnityPackage

  fun isDescriptorInitialized(): Boolean = ::descriptor.isInitialized

  override fun wrapAsModifiable(diff: MutableEntityStorage): ModifiableWorkspaceEntity<UnityPackageEntity> {
    val modifiable = UnityPackageEntityImpl.Builder(null)
    modifiable.allowModifications {
      modifiable.diff = diff
      modifiable.snapshot = diff
      modifiable.id = createEntityId()
      modifiable.entitySource = this.entitySource
    }
    modifiable.changedProperty.clear()
    return modifiable
  }

  override fun createEntity(snapshot: EntityStorage): UnityPackageEntity {
    val entity = UnityPackageEntityImpl()
    entity._descriptor = descriptor
    entity.entitySource = entitySource
    entity.snapshot = snapshot
    entity.id = createEntityId()
    return entity
  }

  override fun getEntityInterface(): Class<out WorkspaceEntity> {
    return UnityPackageEntity::class.java
  }

  override fun serialize(ser: EntityInformation.Serializer) {
  }

  override fun deserialize(de: EntityInformation.Deserializer) {
  }

  override fun createDetachedEntity(parents: List<WorkspaceEntity>): WorkspaceEntity {
    return UnityPackageEntity(descriptor, entitySource) {
    }
  }

  override fun getRequiredParents(): List<Class<out WorkspaceEntity>> {
    val res = mutableListOf<Class<out WorkspaceEntity>>()
    return res
  }

  override fun equals(other: Any?): Boolean {
    if (other == null) return false
    if (this::class != other::class) return false

    other as UnityPackageEntityData

    if (this.entitySource != other.entitySource) return false
    if (this.descriptor != other.descriptor) return false
    return true
  }

  override fun equalsIgnoringEntitySource(other: Any?): Boolean {
    if (other == null) return false
    if (this::class != other::class) return false

    other as UnityPackageEntityData

    if (this.descriptor != other.descriptor) return false
    return true
  }

  override fun hashCode(): Int {
    var result = entitySource.hashCode()
    result = 31 * result + descriptor.hashCode()
    return result
  }

  override fun hashCodeIgnoringEntitySource(): Int {
    var result = javaClass.hashCode()
    result = 31 * result + descriptor.hashCode()
    return result
  }

  override fun collectClassUsagesData(collector: UsedClassesCollector) {
    collector.add(UnityPackage::class.java)
    collector.add(UnityGitDetails::class.java)
    collector.add(UnityPackageSource::class.java)
    this.descriptor?.let { collector.addDataToInspect(it) }
    collector.sameForAllEntities = true
  }
}

using Unity.Burst;
using System;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;

namespace Unity
{

    namespace Entities
    {
        public ref struct SystemState
        {
        }

        public interface ISystem
        {
            void OnCreate(ref SystemState state);

            void OnDestroy(ref SystemState state);

            void OnUpdate(ref SystemState state);
        }


        public interface ISystemStartStop
        {
         
            void OnStartRunning(ref SystemState state);

            void OnStopRunning(ref SystemState state);
        }

        public interface ISystemCompilerGenerated
        {
            void OnCreateForCompiler(ref SystemState state);
        }
    }

    namespace Burst
    {
        public class BurstCompileAttribute : Attribute
        {
        }

        public class BurstDiscardAttribute : Attribute
        {
        }
    }
}

public partial struct EatSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        InternalOnCreate();
    }

    private void InternalOnCreate()
    {
        var l = new List<int>();
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        InternalOnDestroy();
    }

    private void InternalOnDestroy()
    {
        var l = new List<int>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        InternalOnUpdate();
    }

    private void InternalOnUpdate()
    {
        var l = new List<int>();
    }

    [BurstCompile]
    public void OnStartRunning(ref SystemState state)
    {
        InternalOnStartRunning();
    }

    private void InternalOnStartRunning()
    {
        var l = new List<int>();
    }

    [BurstCompile]
    public void OnStopRunning(ref SystemState state)
    {
        InternalOnStopRunning();
    }

    private void InternalOnStopRunning()
    {
        var l = new List<int>();
    }

    [BurstCompile]
    public void OnCreateForCompiler(ref SystemState state)
    {
        InternalOnCreateForCompiler();
    }

    private void InternalOnCreateForCompiler()
    {        
        var l = new List<int>();
    }
}

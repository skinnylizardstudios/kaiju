# Burst-Optimized Kaiju System - Implementation Guide

## Overview

The Kaiju animation system has been refactored to use **Unity Job System** with **Burst compilation** for industry-standard performance optimization.

- **Burst Compilation**: AOT (Ahead-Of-Time) compilation to native code for 10-100x faster math operations
- **Job System Threading**: Safe parallelization using Unity's job scheduler
- **SIMD Optimization**: Automatic vectorization of math operations via Unity.Mathematics
- **Memory-Efficient**: Structured data approach avoids GC allocations in hot paths

## Architecture

### Core Components

#### 1. **KaijuAnimationData.cs**
Defines burst-compatible data structures:

- AnimationOutput
- AnimationInput
- AnimationParameters
- KaijuAnimMath

**Key Design**:
- No MonoBehaviour or Transform references in job code
- Uses `Unity.Mathematics` (float3, quaternion) instead of UnityEngine types
- All public methods marked `[BurstCompatible]`

#### 2. **KaijuAnimationJobs.cs**
Burst-compiled job definitions for:
- HeadBobJob
- ArmSwingJob
- TorsoMotionJob
- BodyDeformationJob
- SkeletalBounceJob
- CombinedAnimationJob

#### 3. **KaijuProceduralAnimatorBurst.cs**
Main animation controller using jobs with support for Immediate and Deferred completion modes.

## Performance Characteristics

| Operation | Standard C# | Burst-Compiled |
|-----------|------------|-----------------|
| Sine calculation | ~20-30 cycles | ~4-5 cycles |
| Vector3 math | Varies | SIMD optimized |
| Loop unrolling | Compiler-dependent | Aggressive |

## Burst Compatibility Rules

**Allowed in Jobs:**
- `Unity.Mathematics` types (float3, quaternion, int4, etc.)
- Primitive types (float, int, bool, etc.)
- Structs containing only the above
- `[BurstCompile]` decorated methods
- `math.*` functions

**NOT Allowed:**
- `UnityEngine.Vector3`, `Quaternion`, etc.
- MonoBehaviour references
- Class types (only structs)
- LINQ, foreach (use for loops)
- Virtual methods
- String operations

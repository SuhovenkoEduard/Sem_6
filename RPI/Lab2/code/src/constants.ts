import { CPU, Diagonal, LocalMemory, OperatingSystem, RandomAccessMemory, Resolution, Tablet } from './types'

export const ERRORS_LOG_FILEPATH = './out/errors.log'
export const RES_TABLETS_FILEPATH = './res/tablets.json'

export const INITIAL_TABLETS: Tablet[] = [
  {
    diagonal: Diagonal._1600x900,
    CPU: CPU.mediatek1200,
    resolution: Resolution.seven,
    operatingSystem: OperatingSystem.android,
    randomAccessMemory: RandomAccessMemory.large,
    localMemory: LocalMemory.large,
  },
  {
    diagonal: Diagonal._1280x720,
    CPU: CPU.snapdragon600,
    resolution: Resolution.five,
    operatingSystem: OperatingSystem.ios,
    randomAccessMemory: RandomAccessMemory.small,
    localMemory: LocalMemory.small,
  },
]

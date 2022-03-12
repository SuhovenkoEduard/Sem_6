export enum Diagonal {
  _2560x1440 = '2560x1440',
  _1920x1080 = '1920x1080',
  _1280x720 = '1280x720',
  _1600x900 = '1600x900',
}

export enum CPU {
  a11 = 'a11',
  snapdragon600 = 'snapdragon600',
  mediatek1200 = 'mediatek1200',
}

export enum Resolution {
  five = '5.0',
  six = '6.0',
  seven = '7.0',
}

export enum OperatingSystem {
  android = 'android',
  ios = 'ios',
  windows = 'windows',
}

export enum RandomAccessMemory {
  small = '1',
  large = '4',
  superLarge = '8',
}

export enum LocalMemory {
  small = '16',
  large = '32',
  superLarge = '64',
}

export type Tablet = {
  diagonal: Diagonal
  CPU: CPU
  resolution: Resolution
  operatingSystem: OperatingSystem,
  randomAccessMemory: RandomAccessMemory,
  localMemory: LocalMemory,
}

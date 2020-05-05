# HaxeUnityBenchmark
Haxeで書いたコードをUnity上で動かすにあたり、どんな方法が良いか検討するための実験コード

## 結果

### Csharp

- Haxe -> CsharpのDLLを作ってUnityに放り込む
- Run on iPhone11Pro: `0.00s / 5000回`
- Compile: `haxe cs.hxml  0.96s user 0.23s system 99% cpu 1.201 total` (HotReloadは出来ない)

## JavaScript - Jint

- [sebastienros/jint](https://github.com/sebastienros/jint)
- Run on iPhone11Pro: `18.64s / 5000回`
- Compile: `haxe js.hxml  0.18s user 0.08s system 98% cpu 0.263 total`

## Lua - xLua

- [Tencent/xLua](https://github.com/Tencent/xLua)
- Run on iPhone11Pro: `1.15s / 5000回`
- Compile: `haxe lua.hxml  0.35s user 0.12s system 97% cpu 0.475 total`

## JavaScript - jurassic

- [paulbartrum/jurassic](https://github.com/paulbartrum/jurassic)
- iOSで動かないので断念

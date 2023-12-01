window.onload = async function () {
  await Blazor.start()

  const box = await createBox()
  alert(box)

  const moved = await MoveBox(box, { x: 10, y: 20, z: 30 })
  alert(moved)
}

async function createBox() {
  return await DotNet.invokeMethodAsync(
    'wasm-csharp-test-1',//Assembly name
    'Box',//the method decorated with [JSInvokable]
  )
}

async function MoveBox(box, direction) {
  return await DotNet.invokeMethodAsync(
    'wasm-csharp-test-1',
    'Move',
    box,
    direction
  )
}

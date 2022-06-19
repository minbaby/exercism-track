# charp/exercises

## 提速脚本

1. rename exercism => exercism_origin (需要重命名可执行文件)
2. `exercism download --exercise=complex-numbers --track=csharp` 可以自动切换到题目目录，然后用 `visual studio code` 打开项目
3. 在命令行执行 `esb` 可以快速提交当前目录的代码
4. `et` 执行测试
5. `etw` watch && 执行测试

```bash
#####################
# exercism, rename exercism => exercism_origin
#####################
esb() {exercism submit -v ${$(ls | grep Tests\.cs)/Tests\.cs/\.cs}}
if [ ! -x "$(command -v exercism)" ]; then
    exercism() {
        arr=($@);
            echo $arr[1];
            if [ $arr[1] = "download" ]; then
                WS=`exercism_origin $@`
                echo "dotnet restore"
                dotnet resotre
                echo "change && open $WS"
                cd $WS
                code $WS
            else
                exercism_origin $@
                echo "not download,"
            fi
        }
else
    err "exercism_origin not found"
fi
alias et="dotnet test"
alias etw="dotnet watch test"
```

function defined(){
        Blockly.JavaScript.INFINITE_LOOP_TRAP = null;
        var code = Blockly.JavaScript.workspaceToCode(workspace);
        // var what = code.split('\n'); //<---------- problem with "if"
        let x = String(code)
        // let y = x.substring(0 , x.length - 1)
        // console.log(x[0]);
        let ans = []
        let check = false
        for ( i = 0 ; i < x.length ; i++){
        if(x[i] == "@" && check == false){
            check = true
        }
        else if(x[i] != "@" && check == true){
            ans.push(x[i])
        }else if(x[i] == "@" && check == true){
            check = false
        }
        }
        ans.pop()
        ans = ans.join("")
        ans = `{"payload":[` + ans + `]}`
        console.log(ans)
        location.href= `code://${ans}?key=1&anotherKey=2`
        return `${ans}`;
}
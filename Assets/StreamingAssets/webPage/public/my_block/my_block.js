// move
Blockly.Blocks['moving_unit'] = {
    init: function () {
        this.appendValueInput("Block")
            .setCheck("Number")
            .appendField("Moving");
        this.appendDummyInput()
            .appendField("Block(s)");
        this.setInputsInline(true);
        this.setPreviousStatement(true, null);
        this.setNextStatement(true, null);
        this.setColour(230);
        this.setTooltip("");
        this.setHelpUrl("");
    }
};

Blockly.JavaScript['moving_unit'] = function (block) {
    var value_block = Blockly.JavaScript.valueToCode(block, 'Block', Blockly.JavaScript.ORDER_ATOMIC);
    // TODO: Assemble JavaScript into code variable.
    // var code = Blockly.JavaScript.workspaceToCode(workspace);
    if(value_block === ""){
        value_block = 0
    }
    let val = block.getFieldValue('Block')
    let id = 'Block'
    // return [id , value_block]
    // return "Move(" + value_block + ")\n";

    return `{"name":"move","value":${value_block}},`
};
// turn
Blockly.Blocks['turning_degree'] = {
    init: function () {
        this.appendValueInput("NAME")
            .setCheck(null)
            .setAlign(Blockly.ALIGN_RIGHT)
            .appendField(new Blockly.FieldLabelSerializable("Turning"), "Turn");
        this.appendDummyInput()
            .appendField("Degrees");
        this.setInputsInline(true);
        this.setPreviousStatement(true, null);
        this.setNextStatement(true, null);
        this.setColour(210);
        this.setTooltip("");
        this.setHelpUrl("");
    }
};

Blockly.JavaScript['turning_degree'] = function (block) {
    var value_block = Blockly.JavaScript.valueToCode(block, 'NAME', Blockly.JavaScript.ORDER_ATOMIC);
    // TODO: Assemble JavaScript into code variable.
    if(value_block === ""){
        value_block = 0
    }
    let val = block.getFieldValue('NAME')
    let id = 'Block'
    // return [id , value_block]
    // return "Turn(" + value_block + ")\n";
    return `{"name":"turn","value":${value_block}},`
};
// if
Blockly.Blocks['if_state'] = {
    init: function () {
        this.appendValueInput("expression")
            .setCheck(null)
            .appendField("if");
        this.appendDummyInput();
        this.appendStatementInput("do")
            .setCheck("Array")
        this.setColour(230);
        this.setPreviousStatement(true, null);
        this.setNextStatement(true, null);
        this.setTooltip("");
        this.setHelpUrl("");
    }
};

Blockly.JavaScript['if_state'] = function (block) {
    var value_expression = Blockly.JavaScript.valueToCode(block, 'expression', Blockly.JavaScript.ORDER_ATOMIC);
    if(value_expression === ""){
        value_expression = `"None"`
    }
    // value_expression.splice(-1 , 1)
    var statements_do = Blockly.JavaScript.statementToCode(block, 'do');
    let x = String(statements_do)
    let y = x.substring(0 , x.length - 1)
    // TODO: Assemble JavaScript into code variable.
    var code = `{"name":"if","expression":${value_expression},"do":[${y}]},`;
    code = String(code)
    expr = []
    for (let i = 0 ; i < code.length ; i++){
        expr.push(code[i])
    }
    expr = expr.join("")
    return expr;
};

Blockly.Blocks['start_block'] = {
    init: function() {
      this.appendStatementInput("NAME")
          .setCheck(null)
          .appendField("Start");
      this.setColour(0);
   this.setTooltip("");
   this.setHelpUrl("");
   this.setDeletable(false);
    }
  };

Blockly.JavaScript['start_block'] = function(block) {
var statements_name = Blockly.JavaScript.statementToCode(block, 'NAME');
// TODO: Assemble JavaScript into code variable.
var code = `@${statements_name}@`;
return code;
};

Blockly.Blocks['jump'] = {
    init: function() {
      this.appendDummyInput()
          .appendField("Jump");
      this.setPreviousStatement(true, null);
      this.setNextStatement(true, null);
      this.setColour(230);
   this.setTooltip("");
   this.setHelpUrl("");
    }
  };

  Blockly.JavaScript['jump'] = function(block) {
    // TODO: Assemble JavaScript into code variable.
    var code = `{"name":"jump"},`;
    return code;
  };

  Blockly.Blocks['turn'] = {
    init: function() {
      this.appendDummyInput()
          .appendField("Turn")
          .appendField(new Blockly.FieldDropdown([["Left","left"], ["Right","right"]]), "NAME");
      this.setPreviousStatement(true, null);
      this.setNextStatement(true, null);
      this.setColour(300);
   this.setTooltip("");
   this.setHelpUrl("");
    }
  };

  Blockly.JavaScript['turn'] = function(block) {
    var dropdown_name = block.getFieldValue('NAME');
    // TODO: Assemble JavaScript into code variable.
    var code = `{"name":"turn","value":"${dropdown_name}"},`;
    console.log(code)
    return code;
  };

  Blockly.Blocks['varGame'] = {
    init: function() {
      this.appendValueInput("NAME")
          .setCheck("String")
          .setAlign(Blockly.ALIGN_CENTRE)
          .appendField("Set Variable")
          .appendField(new Blockly.FieldDropdown([["x","InputX"], ["y","InputY"], ["z","InputZ"]]), "Var")
          .appendField("to");
      this.setPreviousStatement(true, null);
      this.setNextStatement(true, null);
      this.setColour(0);
   this.setTooltip("");
   this.setHelpUrl("");
    }
  };

  Blockly.JavaScript['varGame'] = function(block) {
    var dropdown_var = block.getFieldValue('Var');
    var value_name = Blockly.JavaScript.valueToCode(block, 'NAME', Blockly.JavaScript.ORDER_ATOMIC);
    // TODO: Assemble JavaScript into code variable.
    var code = 'None Define';
    return code;
  };


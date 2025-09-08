const sql = require("../DBHandler/connection");

const Character = function (character){
    this.cno = character.cno;
    this.user_uno = character.user_uno;
    this.cname = character.cname;
    this.ctribe = character.ctribe;
    this.clv = character.clv;
    this.cgender = character.cgender;
    this.cclass = character.cclass;
    this.str = character.str;
    this.dex = character.dex;
    this.wisd = character.wisd;
    this.hp = character.hp;
    this.mana = character.mana;
};

Character.findByuno = (uno, result) => {
    sql.query("CALL `sp_select_characterbyuno`(?)", uno, (err, res) => {
        if (err) {
            console.log("error: ", err);
            result(err, null);
            return;
        }
        if (res.length) {
            result(null, res[0]);// res[0]은 db에서 나오는 결과값
            return;
        }
        result({ kind: "not_found" }, null);
    });
};

Character.create = (newCharacter, result) => {
    sql.query("CALL `sp_insert_character`(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", [newCharacter.user_uno, newCharacter.cname, newCharacter.ctribe, newCharacter.clv, newCharacter.cgender, newCharacter.cclass, newCharacter.str, newCharacter.dex, newCharacter.wisd, newCharacter.hp, newCharacter.mana], (err, res) => {
        if (err) {
            console.log("error: ", err);
            result(err, null);
            return;
        }

        var string = JSON.stringify(res[0]);
        var json = JSON.parse(string);
        result(null, { cno: json[0].cno });
    });
};


Character.update = (newCharacter, result) => {
    sql.query("CALL `sp_update_character`(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);", [newCharacter.cno, newCharacter.cname, newCharacter.ctribe, newCharacter.clv, newCharacter.cgender, newCharacter.cclass, newCharacter.str, newCharacter.dex, newCharacter.wisd, newCharacter.hp, newCharacter.mana], (err, res) => { 
        if (err) {
            console.log("error: ", err);
            result(err, null);
            return;
        }

        var string = JSON.stringify(res[0]);
        var json = JSON.parse(string);
        result(null, { errorcode: json[0].errorcode });
    });
}

Character.delete = (cno, result) => {
    sql.query("CALL `sp_delete_character`(?);", cno, (err, res) => {
        if (err) {
            console.log("error: ", err);
            result(err, null);
            return;
        }
        if (res.length) {
            result(null, res[0]);// res[0]은 db에서 나오는 결과값
            return;
        }
        result({ kind: "not_found" }, null);
    });
};

module.exports = Character;
const Character = require("./character.model");

exports.findeOne = (req, res) => {
    Character.findByuno(req.params.uno, (err, data) => {
        if (err) {
            if (err.kind === "not_found") {
                res.status(404).send({
                    "errcode": "E0400",
                    "data": `Not found Character with uno ${req.params.uno}.`
                })
            }
            else {
                res.status(500).send({
                    "errcode": "E0500",
                    "data": "Error retrieving Character with uno" + req.params.uno
                });
            }
        }
        else
            //res.send(data);
            res.send({ "errcode": "E0000", "data": JSON.stringify(data) });
    });
};

exports.create = (req, res) => {
    if (!req.body) {
        res.status(400).send({
            "errcode": "E0400",
            "data": "Content can not be empty!"
        });
    }

    const character = new Character({
        user_uno : req.body.user_uno,
        cname : req.body.cname,
        ctribe : req.body.ctribe,
        clv : req.body.clv,
        cgender : req.body.cgender,
        cclass : req.body.cclass,
        str : req.body.str,
        dex : req.body.dex,
        wisd : req.body.wisd,
        hp : req.body.hp,
        mana : req.body.mana
    });

    Character.create(character, (err, data) => {
        if (err)
            res.status(500).send({
                "errcode": "E0500",
                "data": err.message || "Some error occured while creating th Character"
            });
        else
            //res.send(data);
            res.send({
                "errcode": "E0000",
                "data": JSON.stringify(data)                
            });
    });


};


exports.update = (req, res) => {
    if (!req.body) {
        res.status(400).send({
            message: "Content can not be empty!"
        });
    }

    const character = new Character({
        cno: req.params.cno,
        cname: req.body.cname,
        ctribe: req.body.ctribe,
        clv: req.body.clv,
        cgender: req.body.cgender,
        cclass: req.body.cclass,
        str: req.body.str,
        dex: req.body.dex,
        wisd: req.body.wisd,
        hp: req.body.hp,
        mana: req.body.mana
    });

    Character.update(character, (err, data) => {
        if (err)
            res.status(500).send({
                message: err.message || "Some error occured while creating th Character"
            });
        else
            res.send(data);
    });

};

exports.delete = (req, res) => {
    Character.delete(req.params.cno, (err, data) => {
        if (err) {
            if (err.kind === "not_found") {
                res.status(404).send({
                    message: `Not found Character with cno ${req.params.uno}.`
                })
            }
            else {
                res.status(500).send({
                    message: "Error retrieving Character with cno" + req.params.uno
                });
            }
        }
        else
            res.send(data);
    });
};
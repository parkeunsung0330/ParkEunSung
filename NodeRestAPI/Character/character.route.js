module.exports = (app) => {
    const character = require("./character.controller");
    app.get("/character/:uno", character.findeOne);
    app.post("/character", character.create);
    app.put("/character/:cno", character.update)
    app.delete("/character/:cno", character.delete)
}   
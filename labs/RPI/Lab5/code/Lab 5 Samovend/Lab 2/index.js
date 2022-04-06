const express = require("express");
const expressHbs = require("express-handlebars");

const port = process.env.PORT || 3000;
const app = express();

app.engine("hbs", expressHbs.engine(
    {
        layoutsDir: "views/layouts",
        defaultLayout: "layout",
        extname: "hbs"
    }
))

const router = require("./routers/index");
const viewRouter = require("./routers/emplViewRouter");

app.set("view engine", "hbs");

app.use(express.json());

app.use("/", viewRouter);
app.use("/api", router);

app.listen(port, (err) =>{
    if (err) {
        console.log(`Error: ${err}`)
    } else {
        console.log(`Server listening at port ${port}`);
    }
});

module.exports = app;

const express = require('express');
const port = process.env.PORT || 3000;
const app = express();

const router = require('./routers/index');
app.use('/api', router);

app.listen(port, (err) => {
  if (err) {
    console.log(`Error: ${err}`)
  } else {
    console.log(`Server listening at port ${port}`);
  }
});

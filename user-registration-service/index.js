const bodyParser = require('body-parser');
const Sequelize = require('sequelize');
const express = require('express');

const app = express();
const sequelize = new Sequelize('sqlite:data/user-api.db');

const port = 8000;

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

require('./app/routes')(app);

sequelize.authenticate().then(() => {
  app.listen(port, () => console.info(`Server listen at ${port}`));
}).catch((err) => {
  console.error('Unable to connect to the database:', err);
});

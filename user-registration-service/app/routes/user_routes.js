const user = require('../models/userModel');

module.exports = (app) => {
  app.post('/users', (req, res) => {
    user.model.create(req.body)
      .then((data) => { res.send(data); });
  });

  app.get('/users', (req, res) => {
    user.model.findAll()
      .then((users) => { res.send(users); });
  });
};

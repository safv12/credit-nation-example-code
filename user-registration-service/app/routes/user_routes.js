const user = require('../models/userModel');
const jwt = require('jsonwebtoken');

module.exports = (app) => {
  /**
   * Creates a new user
   */
  app.post('/users', (req, res) => {
    user.model.create(req.body)
      .then((data) => { res.send(data); });
  });

  /**
   * Get all registered users
   */
  app.get('/users', (req, res) => {
    user.model.findAll()
      .then((users) => { res.send(users); });
  });

  /**
   * Authenticate a user
   */
  app.post('/token', (req, res) => {
    user.model.findOne({
      where: { email: req.body.email, password: req.body.password },
    }).then((data) => {
      if (!data) {
        return res.status(401).send({
          errorCode: 'Unauthorized',
          message: 'Email or password is invalid.',
        });
      }

      // Authenticated
      return res.send({
        tokenType: 'Bearer',
        authToken: jwt.sign({
          userId: data.id,
        }, process.env.JWT_SECRET, { expiresIn: 60 * 60 }),
      });
    });
  });
};

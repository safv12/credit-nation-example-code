const Sequelize = require('sequelize');

const sequelize = new Sequelize('sqlite:data/user-api.db');

const User = sequelize.define('user', {
  id: {
    type: Sequelize.UUID,
    primaryKey: true,
    defaultValue: Sequelize.UUIDV4,
  },
  name: { type: Sequelize.STRING },
  lastName: { type: Sequelize.STRING },
  birthDate: { type: Sequelize.DATE },
});

User.sync({ force: true });

exports.model = User;

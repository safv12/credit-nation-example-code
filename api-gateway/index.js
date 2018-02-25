const express = require("express");
const proxy = require("express-http-proxy");
const jwtAuthorizer = require("./middlewares/jwt-authorizer");
const morgan = require('morgan');

const app = express();
app.use(morgan('dev'));

// Health check endpoints
app.get("/health", (req, res, next) => res.send({ isAlive: true }));

// User registration service endpoints
app.post('/users', proxy(process.env.USER_REGISTRATION_SERVICE_URL));
app.get('/users', jwtAuthorizer.validate, proxy(process.env.USER_REGISTRATION_SERVICE_URL));
app.post('/token', proxy(process.env.USER_REGISTRATION_SERVICE_URL));

app.listen(9001, () => console.info("Api Gateway listen at: " + 9001));

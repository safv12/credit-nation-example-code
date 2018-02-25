const express = require("express");
const httpProxy = require("express-http-proxy");
const jwtAuthorizer = require("./middlewares/jwt-authorizer");
const morgan = require('morgan');

const app = express();
app.use(morgan('dev'));

const userServiceProxy = httpProxy('user-registration-svc');

// Public endpoints
app.get("/health/", (req, res, next) => res.send({ isAlive: true }));
app.post("/token/", (req, res, next) => userServiceProxy(req, res, next));
app.post("/users/", (req, res, next) => userServiceProxy(req, res, next));

// Authentication
app.use((req, res, next) => {
  jwtAuthorizer.validate(req, res, next);
  next();
});

// User Service proxy requests
app.get("/users/", (req, res, next) => userServiceProxy(req, res, next));

app.listen(9001, () => console.info("Api Gateway listen at: " + 9001));

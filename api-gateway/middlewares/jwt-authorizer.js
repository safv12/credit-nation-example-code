const jwt = require("jsonwebtoken");
const secret = process.env.JWT_SECRET;

/**
 * Validates the Authorization header and
 * ensures that the JWT is valid
 * @param {*} req
 * @param {*} res
 * @param {*} next
 */
exports.validate = (req, res, next) => {
  var token = req.headers["authorization"];

  if (token) {
    jwt.verify(token, secret, (err, decoded) => {
      if (err) {
        return res.json({
          errorCode: "Unauthorized",
          message: "The provided token is invalid or expired."
        });
      }

      req.decoded = decoded;
      next();
    });
  } else {
    return res.status(403).send({
      errorCode: "Unauthorized",
      message: "Authorization token was not provided."
    });
  }
};

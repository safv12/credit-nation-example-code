FROM node:carbon

WORKDIR /app

COPY package.json .
RUN npm install

COPY . .

EXPOSE 9001

ENTRYPOINT [ "npm", "start" ]

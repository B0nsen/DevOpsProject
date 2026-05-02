FROM node:18-alpine
WORKDIR /app


ENV NODE_ENV=production


COPY package*.json ./


RUN npm install --include=dev


COPY . .


RUN npm run build

EXPOSE 3000
CMD ["npm", "run", "preview", "--", "--host", "0.0.0.0", "--port", "3000"]
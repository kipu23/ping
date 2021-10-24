# Stage 0, "build-stage", based on Node.js, to build and compile Angular
FROM node:16 as build-stage

WORKDIR /app
COPY src/ui/  /app/
RUN npm install

# build prod version

ARG configuration=production
RUN npm run build -- --output-path=./dist/out --configuration=$configuration

# Stage 1, based on Nginx, to have only the compiled app, ready for production with Nginx
FROM nginx:1.21
COPY --from=build-stage /app/dist/out/ /usr/share/nginx/html
#COPY src/CLIENT/nginx-custom.conf /etc/nginx/conf.d/default.conf

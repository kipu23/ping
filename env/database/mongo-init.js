print('Starting mongo-init.js #################################################################');

db = db.getSiblingDB('ping');

db.createUser({
    user: 'ping',
    pwd: 'pong',
    roles: [
      {
        role: 'readWrite',
        db: 'ping'
      }
    ]
});

db.createCollection('pings');
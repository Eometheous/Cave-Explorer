const { db } = require('@vercel/postgres');

async function createUsersTable(client) {
  try {
    await client.sql`CREATE EXTENSION IF NOT EXISTS "uuid-ossp"`;
    // Create the "users" table if it doesn't exist
    const createTable = await client.sql`
      CREATE TABLE IF NOT EXISTS users (
        id UUID DEFAULT uuid_generate_v4() PRIMARY KEY,
        name VARCHAR(255) NOT NULL,
        email TEXT NOT NULL UNIQUE,
        password TEXT NOT NULL
      );
    `;

    console.log(`Created "users" table`);

  } catch (error) {
    console.error('Error creating table', error);
    throw error;
  }
}

async function main() {
  const client = await db.connect();

  await createUsersTable(client);

  await client.end();
}

main().catch((err) => {
  console.error(
    'An error occurred while attempting to initialize the database:',
    err,
  );
});

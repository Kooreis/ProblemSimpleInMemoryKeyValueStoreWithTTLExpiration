Here is a simple implementation of an in-memory key-value store with TTL expiration in JavaScript:

```javascript
class KeyValueStore {
    constructor() {
        this.store = {};
    }

    set(key, value, ttl) {
        if (this.store[key]) {
            clearTimeout(this.store[key].timeoutId);
        }

        const timeoutId = setTimeout(() => {
            delete this.store[key];
        }, ttl);

        this.store[key] = { value, timeoutId };
    }

    get(key) {
        const data = this.store[key];
        return data ? data.value : null;
    }
}

const store = new KeyValueStore();

store.set('key1', 'value1', 5000);
console.log(store.get('key1')); // 'value1'

setTimeout(() => {
    console.log(store.get('key1')); // null
}, 6000);
```

In this code, we create a `KeyValueStore` class with a `store` object to hold our key-value pairs. The `set` method sets a key-value pair in the store and starts a timeout to delete the key-value pair after the specified TTL (time to live). If the key already exists in the store, we clear the existing timeout before setting the new value and starting a new timeout. The `get` method retrieves the value for a key from the store, or returns `null` if the key does not exist.
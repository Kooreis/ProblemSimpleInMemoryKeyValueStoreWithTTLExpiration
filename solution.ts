Here is a simple implementation of an in-memory key-value store with TTL expiration in TypeScript:

```typescript
class KeyValueStore {
    private store: { [key: string]: { value: any, timeoutId: NodeJS.Timeout } } = {};

    set(key: string, value: any, ttl: number) {
        if (this.store[key]) {
            clearTimeout(this.store[key].timeoutId);
        }

        const timeoutId = setTimeout(() => {
            delete this.store[key];
        }, ttl);

        this.store[key] = { value, timeoutId };
    }

    get(key: string) {
        const item = this.store[key];
        return item ? item.value : null;
    }
}

const store = new KeyValueStore();
store.set('key1', 'value1', 5000);
console.log(store.get('key1')); // 'value1'
setTimeout(() => console.log(store.get('key1')), 6000); // null
```

In this code, we define a `KeyValueStore` class with a `store` property that holds the key-value pairs. Each value in the store is an object with the actual value and a timeout ID. The `set` method sets a value in the store with a given TTL (time to live) in milliseconds. If the key already exists in the store, it clears the existing timeout. It then sets a new timeout to delete the key from the store after the TTL expires. The `get` method retrieves a value from the store. If the key does not exist in the store, it returns `null`.
set(key, value, ttl) {
        if (this.store[key]) {
            clearTimeout(this.store[key].timeoutId);
        }

        const timeoutId = setTimeout(() => {
            delete this.store[key];
        }, ttl);

        this.store[key] = { value, timeoutId };
    }
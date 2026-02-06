<script lang="ts">
    let title = '';
    let categoryName = '';

    async function submit() {
        await fetch('http://localhost:5166/events', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({title, categoryName})
        });

        window.location.href = '/';
    }

</script>

<h1>Add event</h1>

<form on:submit|preventDefault={submit}>
    <div>
        <label>
            Title<br/>
            <input bind:value={title} required/>
        </label>
    </div>

    <div>
        <label>
            Category<br/>
            <input bind:value={categoryName} required/>
        </label>
    </div>

    <button type="submit">Create</button>

</form>

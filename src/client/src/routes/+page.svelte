<script lang="ts">
    export let data;
</script>

<h1>Evenemang</h1>
<a href="/add-event">
    <button>Add Event</button>
</a>

<ul>
    {#each data.events as event}
        <li>
            <strong>{event.title}</strong>
            – {event.categoryName}
        </li>
    {/each}
</ul>

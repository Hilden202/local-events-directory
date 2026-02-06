<script lang="ts">
    export let data;
</script>

<h1>Events</h1>
<a href="/add-event">
    <button>Add Event</button>
</a>

<ul>
    {#each data.events as event}
        <li class="event-row">
            <span>{event.title}</span>
            <a class="link" href={`/events/${event.id}`} title="Edit">⋮</a>
        </li>

    {/each}
</ul>
<style type="text/css">
    .event-row:hover .link {
        opacity: 1;
    }
    .link {
        text-decoration: none;
        cursor: pointer;
    }
</style>
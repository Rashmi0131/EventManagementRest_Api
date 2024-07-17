using AutoMapper;
using EventManagementAPICRUD.DTO_s;
using EventManagementAPICRUD.Models;
using EventManagementAPICRUD.Reporsitory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPICRUD.Controllers
{
    [Route("api/events")]
    [ApiController]
   
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventController(IEventRepository _eventRepository, IMapper mapper)
        {
            this._eventRepository = _eventRepository;
            _mapper = mapper;
        }
        [HttpGet()]
        public async Task<ActionResult<List<Event>>> GetEvents()
        {
            try
            {
                var data = await _eventRepository.GetAllEventsAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching the events, " + ex.Message);
            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEventByIdAsync(int id)
        {
            try
            {
                var eventData = await _eventRepository.GetEventByIdAsync(id);

                if (eventData == null)
                {
                    return NotFound(id);
                }

                return Ok(eventData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching the event , " + ex.Message);
            }
        }
        [Authorize]
        [HttpPost()]
        public async Task<ActionResult<Event>> CreateEventAsync(EventDTO eventDTO)
        {
            try
            {
                Event objEvent = _mapper.Map<Event>(eventDTO);
                var createdEvent = await _eventRepository.CreateEventAsync(objEvent);

                return createdEvent ? Ok("Event Created Successfully.") : StatusCode(500, "Error occured");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the event.");
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Event>> UpdateEventAsync(int id, Event objEvent)
        {
            if (id != objEvent.Id)
            {
                return BadRequest("Event ID Don't Match.");
            }

            try
            {
                var updatedEvent = await _eventRepository.UpdateEventAsync(objEvent);
                return Ok(updatedEvent);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while updating the event.");
            }

        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var deletedEvent = await _eventRepository.DeleteEventAsync(id);
            if (deletedEvent == null)
                return NotFound();

            return Ok(deletedEvent);

        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchEvent([FromQuery] SearchEvent searchEvent)
        {
            var events = await _eventRepository.SearchEventAsync(searchEvent);
            return Ok(events);
        }
    }
}

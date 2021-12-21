using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManageAPI.Data;
using TaskManageAPI.Models;

namespace TaskManageAPI.Controllers
{

    [EnableCors]
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MyTasksController : ControllerBase
    {
        private readonly TaskManageAPIContext _context;

        public MyTasksController(TaskManageAPIContext context)
        {
            _context = context;
        }



        /// <summary>
        /// Get all the tasks 
        /// </summary>
        // GET: api/MyTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyTask>>> GetMyTask()
        {
            return await _context.MyTask.ToListAsync();
        }

        /// <summary>
        /// Get all the tasks by owner ID
        /// </summary>
        // GET: api/MyTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyTask>>> GetMyTaskbyOwner(int id)
        {
            return await _context.MyTask.Where(t => t.OwnerId == id).ToListAsync();
        }


        /// <summary>
        /// Get Task By ID
        /// </summary>
        // GET: api/MyTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyTask>> GetMyTask(int id)
        {
            var myTask = await _context.MyTask.FindAsync(id);

            if (myTask == null)
            {
                return NotFound();
            }

            return myTask;
        }



        // GET: api/MyTasks/5
        [HttpGet("{title}")]
        public async Task<ActionResult<MyTask>> GetMyTaskByTitle(string title)
        {
            var myTask = await _context.MyTask.Where(task => task.TaskName == title).SingleAsync();

            if (myTask == null)
            {
                return NotFound();
            }

            return myTask;
        }



        /// <summary>
        /// Update Task 
        /// </summary>
        // PUT: api/MyTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyTask(int id, MyTask myTask)
        {
            if (id != myTask.MyTaskId)
            {
                return BadRequest();
            }

            _context.Entry(myTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyTaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        /// <summary>
        /// Create New task
        /// </summary>
        // POST: api/MyTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors]
        [HttpPost]
        public async Task<ActionResult<MyTask>> PostMyTask(MyTask myTask)
        {
            _context.MyTask.Add(myTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyTask", new { id = myTask.MyTaskId }, myTask);
        }




        /// <summary>
        /// Delete Task
        /// </summary>
        // DELETE: api/MyTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyTask(int id)
        {
            var myTask = await _context.MyTask.FindAsync(id);
            if (myTask == null)
            {
                return NotFound();
            }

            _context.MyTask.Remove(myTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MyTaskExists(int id)
        {
            return _context.MyTask.Any(e => e.MyTaskId == id);
        }



        /// <summary>
        /// Get all the tasks that are Completed
        /// </summary>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyTask>>> GetMyTaskCompleted()
        {
            var list = await _context.MyTask.Where(task => task.Status == "Completed").ToListAsync();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }





        /// <summary>
        /// Get all the tasks that are In Progress
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyTask>>> GetMyTaskInProgress()
        {
            var list = await _context.MyTask.Where(task => task.Status == "In Progress").ToListAsync();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }




        /// <summary>
        /// Get all the tasks that are yet To Start
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyTask>>> GetMyTaskYetToStart()
        {
            var list = await _context.MyTask.Where(task => task.Status == "Yet To Start").ToListAsync();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }





        /// <summary>
        /// Get all the tasks that are in Do priority
        /// </summary>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyTask>>> GetMyTaskDo()
        {
            var list = await _context.MyTask.Where(task => task.Priority == "Do").ToListAsync();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }




        /// <summary>
        /// Get all the tasks that are In Delegate Priority
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyTask>>> GetMyTaskDelegate()
        {
            var list = await _context.MyTask.Where(task => task.Status == "Delegate").ToListAsync();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }




        /// <summary>
        /// Get all the tasks that are in Shedule Priority
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyTask>>> GetMyTaskShedule()
        {
            var list = await _context.MyTask.Where(task => task.Status == "Shedule").ToListAsync();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        /// <summary>
        /// Get all the tasks that are in eliminate Priority
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyTask>>> GetMyTaskEliminate()
        {
            var list = await _context.MyTask.Where(task => task.Status == "Eliminate").ToListAsync();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }



    }
}

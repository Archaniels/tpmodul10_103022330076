using Microsoft.AspNetCore.Mvc;
using tpmodul10_103022330076.Model;
using System.Collections.Generic;
using static tpmodul10_103022330076.Model.DataMahasiswa;

namespace MahasiswaController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> ListMahasiswa = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Daniyal Arshaq Sudrajat", Nim = "103022330076" },
            new Mahasiswa { Nama = "Admiral Manan Badawi", Nim = "103022300060" },
            new Mahasiswa { Nama = "Raditya Maheswara Putra", Nim = "103022330026" },
            new Mahasiswa { Nama = "Azka Nadzif Athallah", Nim = "103022300165" },
            new Mahasiswa { Nama = "Alif Satria Waskita", Nim = "103022300133" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetMahasiswa()
        {
            return Ok(ListMahasiswa);
        }

        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetMahasiswaIndex(int index)
        {
            if (index < 0 || index >= ListMahasiswa.Count)
            {
                return NotFound();
            }

            return Ok(ListMahasiswa[index]);
        }

        [HttpPost]
        public ActionResult<Mahasiswa> CreateMahasiswa([FromBody] Mahasiswa mahasiswaBaru)
        {
            ListMahasiswa.Add(mahasiswaBaru);
            return CreatedAtAction(nameof(GetMahasiswaIndex), new { index = ListMahasiswa.Count - 1 }, mahasiswaBaru);
        }

        [HttpDelete("{index}")]
        public IActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= ListMahasiswa.Count)
            {
                return NotFound();
            }

            ListMahasiswa.RemoveAt(index);
            return NoContent();
        }
    }
}

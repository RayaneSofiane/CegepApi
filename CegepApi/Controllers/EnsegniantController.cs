using APIGestionCegep.Logics.Controleurs;
using APIGestionCegep.Logics.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CegepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnsegniantControler : ControllerBase
    {
        /// <summary>
        /// obtien la liste des Ensegniants d'un cegep en utilisant le nom du cegep
        /// </summary>
        /// <param name="nomCegep"> le cegep qui pocede les Ensegniants </param>
        /// <returns>la liste des Ensegniants</returns>
        [Route("ObtenirListeEnsegniant")]
        [HttpGet]
        public IActionResult ObtenirListeEnseignant(string nomCegep,string nomDepartement)
        {
            try
            {
                IEnumerable<EnseignantDTO> listeDepartement = CegepControleur.Instance.ObtenirListeEnseignant(nomCegep,nomDepartement);
                return Ok(listeDepartement);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        /// <summary>
        /// obtien un Enseignant d'un cegep en utilisant le nom du cegep et le nom du Enseignant
        /// </summary>
        /// <param name="nomCegep">le nom du cegep</param>
        /// <param name="nomDepartement">le nom du departement</param>
        /// <param name="numeroEnseignant">le nunero de l'Enseignant</param>
        /// <returns>le Enseignant voulu</returns>
        [Route("ObtenirEnseignant")]
        [HttpGet]
        public IActionResult ObtenirEnseignant(string nomCegep,string nomDepartement, int numeroEnseignant)
        {
            try
            {
                IEnumerable<EnseignantDTO> enseignant = (IEnumerable<EnseignantDTO>)CegepControleur.Instance.ObtenirEnseignant(nomCegep,nomDepartement ,numeroEnseignant);
                return Ok(enseignant);
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }

        }
        /// <summary>
        /// ajoute un departement a un cegep en utilisant le nom du cegep et du departement
        /// </summary>
        /// <param name="nomCegep">le nom du cegep</param>
        /// <param name="departement">le nom du departement</param>
        /// <returns></returns>
        [Route("AjouterEnseignant")]
        [HttpPost]
        public IActionResult AjouterEnseignant(string nomCegep,string nomDepartement, [FromBody] EnseignantDTO ensegniant)
        {
            try
            {
                CegepControleur.Instance.AjouterEnseignant(nomCegep, nomDepartement,ensegniant);
                return Ok(ensegniant);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        /// <summary>
        /// modiie un departement en utilisant le nom du cegep et du departement
        /// </summary>
        /// <param name="nomCegep"></param>
        /// <param name="departement"></param>
        /// <returns></returns>
        [Route("ModifierEnseignantt")]
        [HttpPut]
        public IActionResult ModifierEnseignant(string nomCegep, string nomDepartement, [FromBody] EnseignantDTO ensegniant)
        {
            try
            {
                CegepControleur.Instance.ModifierEnseignant(nomCegep, nomDepartement, ensegniant);
                return Ok(ensegniant);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        /// <summary>
        /// suprime un Enseignant en utilisant le nom du cegep et du departement
        /// </summary>
        /// <param name="nomCegep">le nom du cegep</param>
        /// <param name="nomDepartement">le nom du departement</param>
        /// <param name="numeroEnseignant">le numero de l'Enseignant a suprimer</param>
        /// <returns></returns>
        [Route("SupprimerEnseignant")]
        [HttpDelete]
        public IActionResult SupprimerEnseignant(string nomCegep, string nomDepartement, int numeroEnseignant)
        {
            try
            {
                CegepControleur.Instance.SupprimerEnseignant(nomCegep,nomDepartement ,numeroEnseignant);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        /// <summary>
        /// vide la liste des Enseignant d'un cegep en utilisant le nom du cegep
        /// </summary>
        /// <param name="nomCegep">le cegep a vider</param>
        /// <returns></returns>
        [Route("ViderListeEnseignant")]
        [HttpDelete]
        public IActionResult ViderListeEnseignant(string nomCegep,string nomDepartement)
        {
            try
            {
                CegepControleur.Instance.ViderListeEnseignant(nomCegep,nomDepartement);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
